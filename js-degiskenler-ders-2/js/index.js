var urunler = new Array();
var fiyatlar = new Array();
var adetler = new Array();
var liste = new Array();

document.getElementById("birinci-ekle").onclick = function () {
    var birinciUrun = document.getElementById("birinci-urun").value;
    var fiyat = document.getElementById("fiyat").value;
    var adet = document.getElementById("adet").value;
    if (fiyat.length > 0 && birinciUrun.length > 0 && adet.length > 0) {
        urunEkle(birinciUrun, fiyat, adet);
    }

};

function urunEkle(_urunAdi, _fiyat, _adet) {
    urunler.push(_urunAdi);
    fiyatlar.push(_fiyat);
    adetler.push(_adet);
    console.log(urunler);
    console.log(fiyatlar);
    console.log(adetler);
    listeyeEkle(_urunAdi, _fiyat, _adet);
}

function listeyeEkle(_urunAdi, _fiyat, _adet) {
    var cikarButton = `<button type="button" onclick="urunCikar(this)">Çıkar</button>`;
    var row = '<tr><td>' + _urunAdi + '</td><td>' + _fiyat + '</td><td>' + _adet + '</td><td>' + cikarButton + '</td></tr>';
    liste.push(row);
    listele();
}
function listele() {
    var listem = "";
    var i;
    for (i = 0; i < liste.length; i++) {
        listem += liste[i];
    }
    document.getElementById("urunler-listesi").innerHTML = listem;
}
function urunCikar(_index) {
    var yeniListe = new Array();
    var i;
    for (i = 0; i < liste.length; i++) {
        if (i != _index) {
            yeniListe.push = liste[i];
        }
    }
    liste=yeniListe;
    listele();
}



// var liste = document.querySelector("#liste table");
// console.log( liste.querySelector("tr:last-child"));
// liste.querySelector("tr:last-child").innerHTML;
