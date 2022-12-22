using Core.Entities.Concrete;
using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintanceTime = "Bakım saati.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 urun olabilir.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten baska bir urun kayitlidir.";
        public static string CategoryLimitExceded = "Kategori limiti asildigi icin yeni urun eklenemiyor.";
        public static string AuthorizationDenied = "Bu eyleme yetkiniz bulunmamaktadır.";
        public static string UserRegistered = "Kayıt başarılı!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı!";
        public static string AccessTokenCreated = "Erişim tokeni başarıyla oluşturuldu!";
        public static string SuccessfulLogin = "Başarılı giriş!";
        public static string PasswordError = "Parola hatası!";
    }
}
