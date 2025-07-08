using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Response;
using WHS.Core.Dto.Fabric;
using System.Transactions;

namespace WHS.Repository.Repository.Receive
{
    public class FabricReceiveRepository: ReceiveRepository<FabricDto, FabricDetailDto>
    {
        public FabricReceiveRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<Response<int>> CreateReceiveAsync(FabricDto fabric, DataTable detail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {

                // Bước 1: Insert bảng cha và lấy ID
                string insertHeaderSql = @"
                    insert into npl_received (mo, style, color, type_detail, supplier, quantity_to_receive, quantity_estimate, npl_type, created_by, modified_by)
                    output inserted.id
                    values (@Mo, @Style, @Color, @FabricType, @Supplier, @QuantityToReceive, @QuantityEstimate, @NPLType, @CreatedBy, @ModifiedBy);";

                int id = await conn.ExecuteScalarAsync<int>(
                    insertHeaderSql, new
                    {
                        fabric.MO,
                        fabric.Style,
                        fabric.Color,
                        fabric.FabricType,
                        fabric.Supplier,
                        fabric.QuantityToReceive,
                        fabric.QuantityEstimate,
                        NPLType = E_NPLType.FABRIC,
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
                    bulkCopy.DestinationTableName = "npl_fabric_detail";

                    // Ánh xạ cột
                    bulkCopy.ColumnMappings.Add("IdReceived", "id_npl_received");
                    bulkCopy.ColumnMappings.Add("Style", "style");
                    bulkCopy.ColumnMappings.Add("Color", "color");
                    bulkCopy.ColumnMappings.Add("FabricType", "fabric_type");
                    bulkCopy.ColumnMappings.Add("Batch", "batch");
                    bulkCopy.ColumnMappings.Add("FabricLength", "fabric_length");
                    bulkCopy.ColumnMappings.Add("LengthUnit", "length_unit");
                    bulkCopy.ColumnMappings.Add("FabricWeight", "fabric_weight");
                    bulkCopy.ColumnMappings.Add("WeightUnit", "weight_unit");
                    bulkCopy.ColumnMappings.Add("RollWidth", "roll_width");
                    bulkCopy.ColumnMappings.Add("WidthUnit", "width_unit");
                    bulkCopy.ColumnMappings.Add("FabricNumber", "fabric_number");
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
        public override async Task<Response<int>> UpdateReceiveAsync(int id, FabricDto fabric, DataTable detail)
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
                    fabric.MO,
                    fabric.Style,
                    fabric.Color,
                    FabricType = fabric.FabricType,
                    fabric.Supplier,
                    fabric.QuantityToReceive,
                    fabric.QuantityEstimate,
                    ModifiedBy = 0,
                    ID = id,
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
                    bulkCopy.ColumnMappings.Add("idReceived", "id_npl_received");
                    bulkCopy.ColumnMappings.Add("style", "style");
                    bulkCopy.ColumnMappings.Add("color", "color");
                    bulkCopy.ColumnMappings.Add("fabricType", "fabric_type");
                    bulkCopy.ColumnMappings.Add("batch", "batch");
                    bulkCopy.ColumnMappings.Add("fabricLength", "fabric_length");
                    bulkCopy.ColumnMappings.Add("lengthUnit", "length_unit");
                    bulkCopy.ColumnMappings.Add("fabricWeight", "fabric_weight");
                    bulkCopy.ColumnMappings.Add("weightUnit", "weight_unit");
                    bulkCopy.ColumnMappings.Add("rollWidth", "roll_width");
                    bulkCopy.ColumnMappings.Add("widthUnit", "width_unit");
                    bulkCopy.ColumnMappings.Add("fabricNumber", "fabric_number");
                    bulkCopy.ColumnMappings.Add("createdBy", "created_by");
                    bulkCopy.ColumnMappings.Add("modifiedBy", "modified_by");

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
        public override async Task<Response<List<FabricDetailDto>>> GetReceiveDetailAsync(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select  id, 
                        style, 
                        color, 
                        fabric_type as fabricType, 
                        batch,
                        fabric_length as fabricLength,
                        length_Unit as lengthUnit,
                        fabric_weight as fabricWeight,
                        weight_unit as weightUnit,
                        roll_width as rollWidth,
                        width_unit as WidthUnit,
                        fabric_number as FabricNumber,
                        quantity_to_received as QuantityToReceived
                from npl_fabric_detail
                where id_npl_received = @ID";

                var result = (await conn.QueryAsync<FabricDetailDto>(sql, new { ID = id })).ToList();
                return Response<List<FabricDetailDto>>.Success(result);
            }
            catch (Exception ex) 
            { 
                return ErrorHandler<List<FabricDetailDto>>.Show(ex);  
            }
        }
    }
}
