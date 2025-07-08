using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Response;

namespace WHS.Repository.Repository.Receive
{
    public class PldgReceiveRepository : ReceiveRepository<PldgDto, PldgDetailDto>
    {
        public PldgReceiveRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<Response<int>> CreateReceiveAsync(PldgDto plsp, DataTable detail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {

                // Bước 1: Insert bảng cha và lấy ID
                string insertHeaderSql = @"
                    insert into npl_received (mo, type_detail, supplier, quantity_to_receive, quantity_estimate, npl_type, created_by, modified_by)
                    output inserted.id
                    values (@Mo, @Type, @Supplier, @QuantityToReceive, @QuantityEstimate, @NPLType, @CreatedBy, @ModifiedBy);";

                int id = await conn.ExecuteScalarAsync<int>(
                    insertHeaderSql, new
                    {
                        plsp.MO,
                        plsp.Type,
                        plsp.Supplier,
                        plsp.QuantityToReceive,
                        plsp.QuantityEstimate,
                        NPLType = E_NPLType.PLDG,
                        CreatedBy = 0,
                        ModifiedBy = 0
                    },
                    transaction: transaction
                );

                // Bước 2: Thêm các giá trị thiếu vào datatable
                // Thêm id_received vào DataTable
                if (!detail.Columns.Contains("IdReceived"))
                    detail.Columns.Add("IdReceived", typeof(int));

                // Thêm created_by vào Datatable
                if (!detail.Columns.Contains("CreatedBy"))
                    detail.Columns.Add("CreatedBy", typeof(int));

                // Thêm modified_by vào Datatable
                if (!detail.Columns.Contains("ModifiedBy"))
                    detail.Columns.Add("ModifiedBy", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["IdReceived"] = id;
                    row["CreatedBy"] = 0;
                    row["ModifiedBy"] = 0;
                }

                // Bước3: Insert bảng con bằng SqlBulkCopy
                using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.DestinationTableName = "npl_pldg_detail";

                    // Ánh xạ cột
                    bulkCopy.ColumnMappings.Add("IdReceived", "id_npl_received");
                    bulkCopy.ColumnMappings.Add("PldgType", "pldg_type");
                    bulkCopy.ColumnMappings.Add("PackCode", "pack_code");
                    bulkCopy.ColumnMappings.Add("PoCode", "po_code");
                    bulkCopy.ColumnMappings.Add("QuantityPerCarton", "quantity_per_carton");
                    bulkCopy.ColumnMappings.Add("NetWeight", "net_weight");
                    bulkCopy.ColumnMappings.Add("GrossWeight", "gross_weight");
                    bulkCopy.ColumnMappings.Add("Color", "color");
                    bulkCopy.ColumnMappings.Add("PldgWeight", "pldg_weight");
                    bulkCopy.ColumnMappings.Add("WeightUnit", "weight_unit");
                    bulkCopy.ColumnMappings.Add("PldgSize", "pldg_size");
                    bulkCopy.ColumnMappings.Add("SizeUnit", "size_unit");
                    bulkCopy.ColumnMappings.Add("QuantityToReceived", "quantity_to_received");
                    bulkCopy.ColumnMappings.Add("CreatedBy", "created_by");
                    bulkCopy.ColumnMappings.Add("ModifiedBy", "modified_by");

                    await bulkCopy.WriteToServerAsync(detail);
                }

                // Commit
                transaction.Commit();

                return Response<int>.Success(id, "Đã tạo NPL thành công!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Chỉnh sửa NPL vải
        /// </summary>
        /// <param name="data"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<int>> UpdateReceiveAsync(int id, PldgDto plsp, DataTable detail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {
                //Bước 1: Update bảng cha npl_received
                string updateHeaderSql = @"
                update npl_received
                set
                    mo = @Mo,
                    style = @Style,
                    color = @Color,
                    type_detail = @FabricType,
                    supplier = @Supplier,
                    quantity_to_receive = @QuantityToReceive,
                    quantity_estimate = @QuantityEstimate,
                    modified_by = @ModifiedBy,
                    modified_at = GETDATE()
                where id_npl_received = @ID;";

                await conn.ExecuteAsync(updateHeaderSql, new
                {
                    plsp.MO,
                    plsp.Type,
                    plsp.Supplier,
                    plsp.QuantityToReceive,
                    plsp.QuantityEstimate,
                    NPLType = E_NPLType.PLSP,
                    CreatedBy = 0,
                    ModifiedBy = 0
                }, transaction: transaction);

                // Bước 2: Update những dòng đã chỉnh sửa


                // Bước 2: Thêm các giá trị thiếu vào datatable
                // Thêm id_received vào DataTable
                if (!detail.Columns.Contains("idReceived"))
                    detail.Columns.Add("idReceived", typeof(int));

                // Thêm created_by vào Datatable
                if (!detail.Columns.Contains("createdBy"))
                    detail.Columns.Add("createdBy", typeof(int));

                // Thêm modified_by vào Datatable
                if (!detail.Columns.Contains("modifiedBy"))
                    detail.Columns.Add("modifiedBy", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["idReceived"] = id;
                    row["createdBy"] = 0;
                    row["modifiedBy"] = 0;
                }

                // Bước3: Insert bảng con bằng SqlBulkCopy
                using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.DestinationTableName = "npl_fabric_detail";

                    // Ánh xạ cột
                    bulkCopy.ColumnMappings.Add("IdReceived", "id_npl_received");
                    bulkCopy.ColumnMappings.Add("PldgType", "pldg_type");
                    bulkCopy.ColumnMappings.Add("PackCode", "pack_code");
                    bulkCopy.ColumnMappings.Add("PoCode", "PoCode");
                    bulkCopy.ColumnMappings.Add("QuantityPerCarton", "quantity_per_carton");
                    bulkCopy.ColumnMappings.Add("NetWeight", "net_weight");
                    bulkCopy.ColumnMappings.Add("GrossWeight", "gross_weight");
                    bulkCopy.ColumnMappings.Add("Color", "color");
                    bulkCopy.ColumnMappings.Add("PldgWeight", "pldg_weight");
                    bulkCopy.ColumnMappings.Add("WeightUnit", "WeightUnit");
                    bulkCopy.ColumnMappings.Add("PldgSize", "pldg_size");
                    bulkCopy.ColumnMappings.Add("SizeUnit", "size_unit");
                    bulkCopy.ColumnMappings.Add("CreatedBy", "created_by");
                    bulkCopy.ColumnMappings.Add("ModifiedBy", "modified_by");

                    await bulkCopy.WriteToServerAsync(detail);
                }

                // Commit
                transaction.Commit();

                return Response<int>.Success(id, "Đã tạo NPL thành công!");
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<List<PldgDetailDto>>> GetReceiveDetailAsync(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select  id, 
                        pldg_type as PldgType, 
                        pack_code as PackCode, 
                        po_code as PoCode, 
                        quantity_per_carton as QuantityPerCarton,
                        net_weight as NetWeight,
                        gross_weight as GrossWeight,
                        color,
                        pldg_weight as PldgWeight,
                        weight_unit as WeightUnit,
                        pldg_size as PldgSize,
                        size_unit as SizeUnit,
                        quantity_to_received as QuantityToReceived
                from npl_pldg_detail
                where id_npl_received = @ID";

                var result = (await conn.QueryAsync<PldgDetailDto>(sql, new { ID = id })).ToList();
                return Response<List<PldgDetailDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PldgDetailDto>>.Show(ex);
            }
        }
    }
}
