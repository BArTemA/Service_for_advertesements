using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertServiceClient.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsModerator { get; set; }
        public int? LocationId { get; set; }
        public decimal? Rating { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePicture { get; set; }

        // Навигационные свойства
        public Location Location { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Review> ReviewsGiven { get; set; }
        public ICollection<Review> ReviewsReceived { get; set; }

        // Вычисляемые свойства (можно заполнять при загрузке)
        public int AdvertisementsCount => Advertisements?.Count ?? 0;
        public int ReviewsCount => ReviewsReceived?.Count ?? 0;
    }

    public class Advertisement
    {
        public int AdvertID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int? LocationID { get; set; }
        public int ViewCount { get; set; }

        // Навигационные свойства
        public User User { get; set; }
        public Category Category { get; set; }
        public Location Location { get; set; }
    }


    public class Location
    {
        public int LocationID { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }


    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


    public class Chat
    {
        public int ChatID { get; set; }
        public int AdvertID { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        // Навигационные свойства
        public Advertisement Advertisement { get; set; }
    }


    public class Message
    {
        public int MessageID { get; set; }
        public int ChatID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }

        // Навигационные свойства
        public Chat Chat { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }


    public class Review
    {
        public int ReviewerID { get; set; }
        public int ReviewedUserID { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        // Навигационные свойства
        public User Reviewer { get; set; }
        public User ReviewedUser { get; set; }
    }


    public class Complaint
    {
        public int UserID { get; set; }
        public int AdvertID { get; set; }
        public string ReasonText { get; set; }
        public DateTime ComplaintDate { get; set; }
        public string Status { get; set; }
        public int? ResolvedByUserID { get; set; }
        public DateTime? ResolutionDate { get; set; }

        // Навигационные свойства
        public User User { get; set; }
        public Advertisement Advertisement { get; set; }
        public User ResolvedByUser { get; set; }
    }
    

    public class Favorite
    {
        public int UserID { get; set; }
        public int AdvertID { get; set; }
        public DateTime AddedDate { get; set; }

        // Навигационные свойства
        public User User { get; set; }
        public Advertisement Advertisement { get; set; }
    }


    public class ViewHistory
    {
        public int UserID { get; set; }
        public int AdvertID { get; set; }
        public DateTime ViewDate { get; set; }

        // Навигационные свойства
        public User User { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
