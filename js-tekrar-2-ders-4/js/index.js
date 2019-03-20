// 1- ekleBtn çalıştığında inputlardan biri boş olursa alert ile hatalısın mesajını göndersin değilse inputların içeriğini alerte göndersin.
function ekleBtn() {
    var input1 = document.getElementById("input1").value;
    var input2 = document.getElementById("input2").value;
    if (input1.length > 0 && input2.length > 0) {
        alert(input1 + " - " + input2);
    }
    else {
        alert("hatalısın!");
    }
}
// 2- bir json variable'ı oluşturun örnek datalı!
var jsonData = {
    id: 1,
    isim: "mahmut",
    dogumTarihi: "01.01.2001"
};
// 3- yeni variable(adı "jsonArr" olsun) array içinde json oluşturun örnek datalı ve en az 3 üyeli!
var jsonArr = [{
    id: 1,
    isim: "mahmut",
    dogumTarihi: "01.01.2001"
}, {
    id: 2,
    isim: "elif",
    dogumTarihi: "09.10.2015"
},
{
    id: 3,
    isim: "hasan",
    dogumTarihi: "01.02.1975"
}
];


// 4- tabloYap() adında bir fonksiyon oluşturun _array diye parametresi olsun. gelen parametreyi for ile dönerek html tablo oluşturup <tbody id="tablom"></tbody> elementinin içine gönderin
function tabloYap(_array) {
    var tablomHtml = "";
    var i;
    // for loop ile yapılışı:
    // for(i=0;i<_array.length;i++){
    //     tablomHtml+=
    //     "<tr>"+
    //     "<td>"+_array[i].id+"</td>"+
    //     "<td>"+_array[i].isim+"</td>"+
    //     "<td>"+_array[i].dogumTarihi+"</td>"+
    //     "<td>buton yok</td>"+
    //     "</tr>";
    // }

    // map ile nasıl yaparız?
    tablomHtml = _array.map(item => {
        var satir = "<tr>" +
            "<td>" + item.id + "</td>" +
            "<td>" + item.isim + "</td>" +
            "<td>" + item.dogumTarihi + "</td>" +
            "<td>buton yok</td>" +
            "</tr>";
        return satir;
    })

    document.getElementById("tablom").innerHTML = tablomHtml.join('');
}

tabloYap(jsonArr);


// 5- jsonArrData diye yeni bir boş array oluşturun
// 6- ekleBtn() fonksiyonu çalıştığında jsonData yapısında bir json'ı jsonArrData'ya push edin
// 7- push işleminin ardından jsonArrData'yı tabloYap() fonksiyonuna parametre olarak gönderip çalıştırın ve tablo oluşsun
// 8- listedenKaldır(_id) fonksiyonu oluşturun sonra tabloYap()'da buton yok yazan yere '<button type="button" onclick="listedenKaldir(\''+buraya id gelecek+'\')">Çıkar</button>' şeklinde güncelleyin.
// 9- listedenKaldır(_id) çalıştığında jsonArrData'dan eşleşen id'li json'ı kaldırın ve yeni jsonArrData ile tekrar tabloYap fonksiyonunu çalıştırın
// 10- searchInput diye bir input oluşturun bu input içerisinde her karakter tuşlamasında listede arama yapsın filters kullanılacak


