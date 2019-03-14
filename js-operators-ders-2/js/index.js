// (+) toplama işlemi
// toplama operatörü
// var toplam = 3 + 5;
// console.log("toplam sonuç:" + toplam);
// //8 sonucu verir;

// // çarpma operatörü
// var carpma = 5 * 4;
// console.log("\nçarpma sonucu:" + carpma);

// // bölme operatörü
// var bolme = 10 / 3;
// console.log("\nbölme sonuç:" + bolme)

// // mod operatörü
// var mod = 10 % 3;
// console.log("\nmod sonuç:" + mod);



//hesap makinesi
function sonucGoster(_sonuc) {
    //id'si sonuc olan element'in içine innerHtml metodu ile yazdır.
    document.getElementById("sonuc").innerHTML = _sonuc;

    document.getElementById("kucuk").innerHTML = "";
    document.getElementById("esit").innerHTML = "";
    document.getElementById("esit-degil").innerHTML = "";
    document.getElementById("besten-buyuk-veya-ondan-buyuk").innerHTML = "";
    document.getElementById("besten-buyuk-ve-ondan-buyuk").innerHTML = "";

    // bestenBuyuk(_sonuc);

    // if (_sonuc > 5) {
    //     bestenBuyuk(_sonuc);
    // }
    // else if (_sonuc < 5) {
    //     bestenKucuk(_sonuc);
    // }

    //shor if nedir?

    _sonuc < 5 ? bestenKucuk(_sonuc) : bestenBuyuk(_sonuc);

    // if (_sonuc !== 5) {
    //     beseEsitDegil(_sonuc);
    // }
    // else if (_sonuc === 5) {
    //     beseEsit(_sonuc);
    // }

    _sonuc !== 5 ? beseEsitDegil(_sonuc) : beseEsit(_sonuc);

    if (_sonuc > 5 || _sonuc > 10) {
        bestenBuyukVeyaOndanBuyuk(_sonuc);
    }
    if (_sonuc > 5 && _sonuc > 10) {
        bestenBuyukVeOndanBuyuk(_sonuc);
    }

}
function bestenBuyuk(_sonuc) {
    if (_sonuc > 5) {
        document.getElementById("buyuk").innerHTML = _sonuc + " BEŞTEN BÜYÜK";
    }
    else {
        document.getElementById("buyuk").innerHTML = "";
    }
}
function bestenKucuk(_sonuc) {
    document.getElementById("kucuk").innerHTML = _sonuc + " BEŞTEN KÜÇÜK";
}
function beseEsit(_sonuc) {
    document.getElementById("esit").innerHTML = _sonuc + " BEŞE EŞİT";
}
function beseEsitDegil(_sonuc) {
    document.getElementById("esit-degil").innerHTML = _sonuc + " BEŞE EŞİT DEĞİL";
}
function bestenBuyukVeyaOndanBuyuk(_sonuc) {
    document.getElementById("besten-buyuk-veya-ondan-buyuk").innerHTML = _sonuc + " BEŞTEN BÜYÜK VEYA ONDAN BÜYÜK";
}
function bestenBuyukVeOndanBuyuk(_sonuc) {
    document.getElementById("besten-buyuk-ve-ondan-buyuk").innerHTML = _sonuc + "BEŞTEN BÜYÜK VE ONDAN BÜYÜK";
}
function topla() {
    // id'si input1 olan inputun değerini var input1'e ata
    var input1 = parseInt(document.getElementById("input1").value);
    // id'si input2 olan inputun değerini var input2'e ata
    var input2 = parseInt(document.getElementById("input2").value);

    //toplama işlemini yap
    var sonuc = input1 + input2;
    //sonucGoster fonksiyonuna
    //sonuc değerini gönder
    sonucGoster(sonuc);


}


function cikarma() {
    // id'si input1 olan inputun değerini var input1'e ata
    var input1 = parseInt(document.getElementById("input1").value);
    // id'si input2 olan inputun değerini var input2'e ata
    var input2 = parseInt(document.getElementById("input2").value);
    //toplama işlemini yap
    var sonuc = input1 - input2;
    //sonucGoster fonksiyonuna
    //sonuc değerini gönder
    sonucGoster(sonuc);
}
function carpma() {
    // id'si input1 olan inputun değerini var input1'e ata
    var input1 = parseInt(document.getElementById("input1").value);
    // id'si input2 olan inputun değerini var input2'e ata
    var input2 = parseInt(document.getElementById("input2").value);
    //toplama işlemini yap
    var sonuc = input1 * input2;
    //sonucGoster fonksiyonuna
    //sonuc değerini gönder
    sonucGoster(sonuc);
}
function bolme() {
    // id'si input1 olan inputun değerini var input1'e ata
    var input1 = parseInt(document.getElementById("input1").value);
    // id'si input2 olan inputun değerini var input2'e ata
    var input2 = parseInt(document.getElementById("input2").value);

    //bölme işlemini yap
    var sonuc = input1 / input2;
    //sonucGoster fonksiyonuna
    //sonuc değerini gönder
    sonucGoster(sonuc);
}
function mod() {
    // id'si input1 olan inputun değerini var input1'e ata
    var input1 = parseInt(document.getElementById("input1").value);
    // id'si input2 olan inputun değerini var input2'e ata
    var input2 = parseInt(document.getElementById("input2").value);
    //mod işlemini yap
    var sonuc = input1 % input2;
    //sonucGoster fonksiyonuna
    //sonuc değerini gönder
    sonucGoster(sonuc);
}
