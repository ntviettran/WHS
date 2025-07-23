using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WHS.Core.Dto.User;
using WHS.Core.ErrorHandle;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.User
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Xử lí login tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<string>> Login(UserDto user)
        {
            //using var httpClient = new HttpClient();

            //var jsonContent = new StringContent(
            //    JsonSerializer.Serialize(user),
            //    Encoding.UTF8,
            //    "application/json"
            //);

            try
            {
                //// Gọi api
                //var response = await httpClient.PostAsync("http://172.16.49.41:44333/api/Authenticate/Signin", jsonContent);

                //if (response.IsSuccessStatusCode)
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    using var doc = JsonDocument.Parse(content);
                //    var root = doc.RootElement;

                //    var status = root.GetProperty("status");

                //    // Nếu status từ api != 200 thì trả về thông báo lỗi
                //    if (status.GetInt32() != 200)
                //    {
                //        var messageJson = root.GetProperty("message");
                //        string message = messageJson.ToString();

                //        return Response<string>.Fail("Tài khoản hoặc mật khẩu không đúng!");
                //    }

                //    // Nếu không có thông báo lỗi, get data và lưu access token
                //    var data = root.GetProperty("data");
                //    if (data.ValueKind == JsonValueKind.Array && data.GetArrayLength() > 0)
                //    {
                //        var firstItem = data[0];
                //        var authCodeJson = firstItem.GetProperty("authCode");
                //        string authCode = authCodeJson.ToString();

                //        Session.AccessToken = authCode;
                //        return Response<string>.Success(authCode, "Đăng nhập thành công!");
                //    }

                //    return Response<string>.Fail("Có lỗi xảy ra từ hệ thống!");
                //}
                //else
                //{
                //    // Lỗi thì trả về lỗi từ hệ thống
                //    var errorMessage = await response.Content.ReadAsStringAsync();
                //    return Response<string>.Fail("Có lỗi xảy ra từ hệ thống!");
                //}

                if (user.UserName == "13779" && user.Password == "Namthuan@")
                {
                    Session.AccessToken = "13779";
                    return Response<string>.Success("13779", "Đăng nhập thành công");
                }

                if (user.UserName == "12579" && user.Password == "Namthuan@")
                {
                    Session.AccessToken = "12579";
                    return Response<string>.Success("12579", "Đăng nhập thành công");
                }

                return Response<string>.Fail("Tài khoản hoặc mật khẩu sai");
            }
            catch (Exception ex) {
                return ErrorHandler<string>.Show(ex);
            }
        }

        /// <summary>
        /// Get ra thông tin của user đã login
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<UserInfoDto>> GetUserInfo()
        {
            // Khai báo http client
            //using var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

            try
            {
                // call api
                //var response = await httpClient.GetAsync("http://172.16.49.41:44333/api/Authenticate/InformationUserLogin");

                //if (response.IsSuccessStatusCode)
                //{
                //    string result = await response.Content.ReadAsStringAsync();
                //    using var doc = JsonDocument.Parse(result);
                //    var root = doc.RootElement;

                //    var status = root.GetProperty("status");

                //    // Nếu status từ api != 200 thì trả về thông báo lỗi
                //    if (status.GetInt32() != 200)
                //    {
                //        var messageJson = root.GetProperty("message");
                //        string message = messageJson.ToString();

                //        return Response<UserInfoDto>.Fail("Có lỗi xảy ra:" + message);
                //    }

                //    // Nếu không có thông báo lỗi, get data và lưu usser info vào session
                //    var data = root.GetProperty("data");
                //    if (data.ValueKind == JsonValueKind.Array && data.GetArrayLength() > 0)
                //    {
                //        var firstItem = data[0];
                //        UserInfoDto userInfo = JsonSerializer.Deserialize<UserInfoDto>(firstItem.GetRawText())!;
                //        Session.CurrentUser = userInfo;

                //        return Response<UserInfoDto>.Success(userInfo, "Lấy thông tin tài khoản thành công!");
                //    }

                //    return Response<UserInfoDto>.Fail("Có lỗi xảy ra từ hệ thống!");
                //}
                //else
                //{
                //    return Response<UserInfoDto>.Fail("Có lỗi xảy ra từ hệ thống!");
                //}


                if (Session.AccessToken == "13779")
                {
                    UserInfoDto user = new UserInfoDto()
                    {
                        CompanyId = 1,
                        DepartmentCode = "PPC",
                        DepartmentId = 1,
                        ID = 1,
                        FullName = "Trần Đức Việt",
                        UserCode = 13779,
                    };

                    Session.CurrentUser = user;
                    return Response<UserInfoDto>.Success(user);
                }

                if (Session.AccessToken == "12579")
                {
                    UserInfoDto user = new UserInfoDto()
                    {
                        CompanyId = 1,
                        DepartmentCode = "WHS",
                        DepartmentId = 2,
                        ID = 2,
                        FullName = "Đỗ Tiến Đạt",
                        UserCode = 12579,
                    };

                    Session.CurrentUser = user;
                    return Response<UserInfoDto>.Success(user);
                }

                return Response<UserInfoDto>.Fail("Lấy thông tin thất bại");
            }
            catch (Exception ex)
            {
                return ErrorHandler<UserInfoDto>.Show(ex);
            }
        }
    }
}
