// 5- Bir tane array tanımlayın (variable) adı "eklenenler" olsun
//var eklenenler = new Array();
var eklenenler = [];

// 1- Ekle adında bir javascript Fonksiyonu oluşturun
// 2- Fonksiyon çalıştığında "Butona tıklandı!" mesajı gönderen alert ekleyin
function Ekle() {
    //3- alert("butona tıklandı");
    //4- alert içini inputun içeriği ile değiştirin
    console.log(document.getElementById("input1").value);
    var param = document.getElementById("input1").value;
    arrayeEkle(param);
}

// 6- Bir tane arrayeEkle diye fonksiyon oluşturun.
// 7- arrayeEkle() fonksiyonuna parametre olarak _gelen tanımlayın
// 8- arrayeEkle() fonksiyonunda gelen parametreyi alert'leyin
// 9- arrayeEkle() fonksiyonunu parametrik olarak Ekle() fonksiyonunda çalıştırın
// * tüm alertleri, console.log'a dönüştür!
// 10- arrayeEkle(_gelen) fonksiyonu _gelen parametresini eklenenler array'ine eklesin
// 11- Sonra array'i console.log'la konsolda görüntüleyin.
function arrayeEkle(_gelen) {
    console.log(_gelen);
    eklenenler.push(_gelen);
    console.log(eklenenler);
}
// 12- yeni bir fonksiyon oluşturun adı arraydeGez() olsun ve for döngüsü içinde console.log ile loglayın;












