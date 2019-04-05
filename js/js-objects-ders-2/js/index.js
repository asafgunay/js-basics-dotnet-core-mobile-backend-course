var araba = {
    marka: "Fiat",
    model: "Punto",
    plaka: "27AFK16",
    renk: "Gri",
    sunRoof: true,
    teker: 4,
    yil: 2013
};

var arabalar = [{
    marka: "Fiat",
    model: "Punto",
    plaka: "27AFK16",
    renk: "Gri",
    sunRoof: true,
    teker: 4,
    yil: 2013
},
{
    marka: "Renault",
    model: "Clio",
    plaka: "16EC285",
    renk: "Bordo",
    sunRoof: false,
    teker: 4,
    yil: 2011
}]

// console.log(araba);

// console.log(arabalar);


// function arabaBilgiGetir(){
//     console.log(araba.model);
//     console.log(araba.marka);
// }

// arabaBilgiGetir();

// function arabaSec(_id){
//     console.log(arabalar[_id].marka);
//     console.log(arabalar[_id].model);
// }

// arabaSec(1);


// function arabalarListele(){
//     var i;
//     for(i=0;i<arabalar.length;i++){
//         console.log(arabalar[i]);
//     }

//     for(item in arabalar){
//         console.log(arabalar[item]);
//     }
// }

// arabalarListele();

//Map metodu
// var arr1 = [1, 2, 3, 5, 6, 7, 8, 9];

// var map1 = arr1.map(x => x * 2);

// console.log(map1);
// var cars = arabalar;

// var cars1 = arabalar.map(araba => araba);
// console.log(cars1);

var arrJson = [{
    anahtar: 1,
    deger: 10
},
{
    anahtar: 2,
    deger: 8

},
{
    anahtar: 3,
    deger: 30
}];

var formatlananArray = arrJson.map(obj => {
    var rObj =
    {
        yeniAnahtar: obj.anahtar * 2,
        yeniDeger: obj.deger * 2,
        yeniGeldi: obj.deger * 3,
        eskiHali: obj
    };
    return rObj;
});

//console.log(formatlananArray);


// array filtreleri
var kelimeler = ["elma", "karpuz", "mandalina", "greyfurt", "pırasa", "kuşkonmaz"];
var sonuc = kelimeler.filter(kelime => kelime.length > 6);
//console.log(sonuc);




































