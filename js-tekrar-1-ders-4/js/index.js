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
    arraydeGez();
}

// 12- yeni bir fonksiyon oluşturun adı arraydeGez() olsun ve for döngüsü içinde console.log ile loglayın;
// 13- arraydeGez() fonksiyonun ilk satırında eklenenlerHtml adında yeni bir variable(yani değişken) tanımlayın.
// 14- for döngüsü içinde eklenenler[i] ile gelen veriyi eklenenlerHtml'e ekleyin.
// 15- eklenenlerHtml'i for'da <li></li> tagı arasına eklenenler[i]'yi ekleyecek şekilde güncelleyin
// 16- index.html'de "eklenenler-listesi" id'li bir div elementi oluşturun
// 17- eklenenlerHtml'i <ul></ul> tagı içerisine alın ve arraydeGez() fonksiyonunun son satırında log'layın!
// 18- "eklenenler-listesi" id'li div'e eklenenlerHtml'i gönder;
function arraydeGez() {
    var eklenenlerHtml = "";
    var i;
    for (i = 0; i < eklenenler.length; i++) {
        console.log(eklenenler[i]);// arrayin i sırasındaki üyesini döner
        // console.log(i); // 0 1 2 index numarasını döner
        // eklenenlerHtml += eklenenler[i] + ", ";
        eklenenlerHtml += "<li>" + eklenenler[i] + "</li>";

    }
    console.log(eklenenlerHtml);
    eklenenlerHtml = "<ul>" + eklenenlerHtml + "</ul>";
    console.log(eklenenlerHtml);
    document.getElementById("eklenenler-listesi").innerHTML = eklenenlerHtml;
}
// 19- listeyiGetir adında bir fonksiyon oluşturun.
// 20- listeyiGetir fonksiyonunda li tagına sahip elementleri liste adında bir variable'a atayın
// 21- for döngüsü içinde li taglarını dön ve console.log ile konsola yazdır.
// 22- listeyiGetir() fonksiyonuna _renk parametresi atayın
// 23- ekle butonu yanına mavi adında ve kırmızı adında iki tane buton ekleyin
// 24- butonların onclick eventine sırasıyla "blue" ve "red" parametrelerini gönderecek fonksiyonlar ekleyin.
// 25- listeyi getir fonksiyonunda bu parametreleri gönderip for döngüsü içerisinde li'lerin renklerini değiştirin.
function listeyiGetir(_renk) {
    var liste = document.getElementsByTagName("li");
    var i;
    for (i = 0; i < liste.length; i++) {
        liste[i].style.color = _renk;
    }
}
















