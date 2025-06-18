using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class ComplainService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public ComplainService()
        {
            _dbService = new DatabaseService();
        }

        public int CreateComplaint(int userId, int advertId, string reasonText)
        {
            var complaintIdParam = new SqlParameter("@ComplaintID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@AdvertID", advertId),
                new SqlParameter("@ReasonText", reasonText),
                complaintIdParam
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_CreateComplaint", parameters);
            return (int)complaintIdParam.Value;
        }

        public DataTable GetComplaintsForModeration(string status = null, int pageNumber = 1, int pageSize = 20)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status ?? (object)DBNull.Value),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetComplaintsForModeration", parameters);
        }

        public void ProcessComplaint(int advertId, int userId, int moderatorId, string newStatus,
                                    string resolutionComment = null, bool banAdvertisement = false,
                                    bool banUser = false)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AdvertID", advertId),
                new SqlParameter("@UserID", userId),
                new SqlParameter("@ModeratorID", moderatorId),
                new SqlParameter("@NewStatus", newStatus),
                new SqlParameter("@ResolutionComment", resolutionComment ?? (object)DBNull.Value),
                new SqlParameter("@BanAdvertisement", banAdvertisement),
                new SqlParameter("@BanUser", banUser)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_ProcessComplaint", parameters);
        }

        public void Dispose()
        {
            _dbService.Dispose();
        }
    }
}