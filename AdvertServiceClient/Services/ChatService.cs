using AdvertServiceClient.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class ChatService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public ChatService()
        {
            _dbService = new DatabaseService();
        }

        public int CreateChat(int advertId, int user1Id, int user2Id)
        {
            var chatIdParam = new SqlParameter("@ChatID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AdvertID", advertId),
                new SqlParameter("@User1ID", user1Id),
                new SqlParameter("@User2ID", user2Id),
                chatIdParam
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_CreateChat", parameters);
            return (int)chatIdParam.Value;
        }

        public DataTable GetChatMessages(int chatId, int userId, int pageNumber = 1, int pageSize = 50)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ChatID", chatId),
                new SqlParameter("@UserID", userId),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetChatMessages", parameters);
        }

        public DataTable GetUserChats(int userId, bool onlyUnread = false, int pageNumber = 1, int pageSize = 20)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@OnlyUnread", onlyUnread),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetUserChats", parameters);
        }

        public void SendMessage(int chatId, int senderId, int receiverId, string content)
        {
            var messageIdParam = new SqlParameter("@MessageID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ChatID", chatId),
                new SqlParameter("@SenderID", senderId),
                new SqlParameter("@ReceiverID", receiverId),
                new SqlParameter("@Content", content),
                messageIdParam
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_SendMessage", parameters);
        }

        public void MarkMessagesAsRead(int chatId, int userId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ChatID", chatId),
                new SqlParameter("@UserID", userId)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_MarkMessagesAsRead", parameters);
        }

        public void CloseChat(int chatId, int userId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ChatID", chatId),
                new SqlParameter("@UserID", userId)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_CloseChat", parameters);
        }

        public void Dispose()
        {
            _dbService.Dispose();
        }
    }
}