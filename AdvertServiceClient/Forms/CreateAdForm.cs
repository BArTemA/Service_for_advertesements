using System;

namespace AdvertServiceClient
{
    public partial class CreateAdForm : EditAdForm
    {
        public CreateAdForm(int userId) : base(userId)
        {
            // Базовый конструктор EditAdForm уже инициализирует все необходимое
            // для создания нового объявления (advertId = 0)
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
        }
    }
}