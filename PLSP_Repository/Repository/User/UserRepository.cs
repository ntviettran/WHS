using Dapper;
using Microsoft.Extensions.Configuration;
using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Dto.User;
using PLSP.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.User;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Repository.Interfaces;
using ZXing.QrCode.Internal;

namespace WHS.Repository.Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Xử lí login tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<UserInfoDto>> GetUser(string ssid)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = "select ssid, code, decentralization, area, limit_quantity, factory_id from sys_whs_user where ssid = @SSID and is_active = 1 and (@FactoryID is null or factory_id = @FactoryID)";

                UserInfoDto? userInfo = await conn.QueryFirstOrDefaultAsync<UserInfoDto>(sql, new {SSID = ssid, FactoryID = Session.CurrentUser.FactoryID != 0 ? (int?)Session.CurrentUser.FactoryID : null});

                if (userInfo != null)
                {
                    return Response<UserInfoDto>.Success(userInfo);
                }

                return Response<UserInfoDto>.Fail("Thẻ này của bạn không có quyền truy cập!");

            }
            catch (Exception ex)
            {
                return ErrorHandler<UserInfoDto>.Show(ex);
            }
        }

        /// <summary>
        /// Láy ra user
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<PageDto<UserInfoDto>>> GetUserPage(Paginate paginate, int? code)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from sys_whs_user";
                string countSql = $"select count(id) {baseSql} where (@Code is null or code = @Code) and decentralization = @Decentralization and area = @Area and is_active = 1 and factory_id = @FactoryID;";
                string dataSql = $@"select * {baseSql}
                                    where (@Code is null or code = @Code) and decentralization = @Decentralization and area = @Area and is_active = 1 and factory_id = @FactoryID
                                    order by id
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Code = code,
                    Decentralization = (int)E_WHType.WORKER,
                    Session.CurrentUser.Area,
                    Session.CurrentUser.FactoryID
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<UserInfoDto> items = (await conn.QueryAsync<UserInfoDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<UserInfoDto> result = new PageDto<UserInfoDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<UserInfoDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<UserInfoDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Tạo user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> CreateUser(UserCreateDto user)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"insert into sys_whs_user (ssid, code, decentralization, area, limit_quantity, created_by, modified_by, factory_id)
                                values (@SSID, @Code, @Decentralization, @Area, @LimitQuantity, @CreatedBy, @CreatedBy, @FactoryID)";

                UserInfoDto currentUser = Session.CurrentUser;

                var parameters = new
                {
                    user.SSID,
                    user.Code,
                    Decentralization = (int)E_WHType.WORKER,
                    currentUser.Area,
                    user.LimitQuantity,
                    CreatedBy = currentUser.Code,
                    Session.CurrentUser.FactoryID
                };

                var result = await conn.ExecuteAsync(sql, parameters);

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Úpdate user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateUser(int id, UserCreateDto user)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"update sys_whs_user 
                               set code = @Code,
                                   limit_quantity = @LimitQuantity,
                                   modified_by = @ModifiedBy,
                                   modified_at = getdate()
                                where id = @ID";

                UserInfoDto currentUser = Session.CurrentUser;

                var parameters = new
                {
                    ID = id, 
                    user.Code,
                    user.LimitQuantity,
                    ModifiedBy = currentUser.Code
                };

                var result = await conn.ExecuteAsync(sql, parameters);

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Xóa user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> DeleteUser(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"update sys_whs_user set is_active = 0 where id = @ID";

                UserInfoDto currentUser = Session.CurrentUser;

                var parameters = new
                {
                    ID = @id
                };

                var result = await conn.ExecuteAsync(sql, parameters);

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }
    }
}
