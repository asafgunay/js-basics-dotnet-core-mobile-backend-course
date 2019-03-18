function girisYap() {
    var kul_adi =
        document.getElementById("kul_adi").value;
    var sifre =
        document.getElementById("sifre").value;

    if (!(kul_adi.length > 0 && sifre.length > 0)) {
        alert("Lütfen geçerli bir kullanıcı adı ve şifre giriniz");
    }
    else {
        if (kul_adi == "admin" && sifre == "1234") {

            document.cookie="username="+kul_adi+";sifre="+sifre;

            var _cookies = document.cookie;
            console.log(_cookies);
            alert("giriş yapıldı");
        }
        else {
            alert("Kullanıcı adı veya Şifre yanlış");
        }
    }
}

var name="hasan";
var value="123";
var path="c://documents/";
var domain="google.com";

var curCookie = name + "=" + value + 
    ", path=" + path + 
    ", domain=" + domain;

document.cookie = curCookie;
 
alert("Your Cookie : " + document.cookie);
