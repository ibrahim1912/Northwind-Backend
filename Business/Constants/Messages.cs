using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants   //bu klasor proje sabitlerini tutar
{
    public static class Messages  //sabit oldugu için static //staticler new lenmez ihtiyaç yok
    {
        public static string ProductAdded = "Ürün eklendi";     //private olsaydı prdouctAdded olurdu
        public static string ProductNameInvalid = "Ürün ismi geçersiz";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoriye en fazla 10 ürün eklenebilir";
        public static string ProductNameAlreadyExist = "Bu listede zaten bu isimde bir ürün var";

        public static string CategoryLimitExceed = "Kategory sayısı aşıldığı için yeni ürün eklenemez";
        public static string CategoryAdded = "Kategori eklendi";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
