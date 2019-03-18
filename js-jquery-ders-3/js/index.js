// function girisYap(){
//     var kul_adi_input_js=document.getElementById("kul_adi").value;
// }
// $("a").click(function(){
//     var kul_adi_input_jquery =$("a").html();
//     console.log(kul_adi_input_jquery);
// });
var ornekArray = [
    {
        gorevAdi: "Çöpü Dök",
        atanan: "Hasan",
        bitisTarihi: "11.12.2019"
    }
];

$("#ekle_btn").click(function () {
    if ($("#gorev_adi").val() && $("#atanan").val() && $("#bitis_tarihi").val()) {
        gorevEkle($("#gorev_adi").val(), $("#atanan").val(), $("#bitis_tarihi").val());
        alert("Eklendi");
    }
    else {
        alert("Lütfen formu kontrol ediniz");
    }
});

function tabloyuAl(_obj) {
    var tablo = _obj.map(item => {
        return "<tr>" +
            "<td>" + item.gorevAdi + "</td>" +
            "<td>" + item.atanan + "</td>" +
            "<td>" + item.bitisTarihi + "</td>" +
            "<td>" +
            "<button type='button' data-val='" + item.id + "' class='islem_btn'>İşlem</button>"
            + "</td>"
            + "</tr>"
    });
    return tablo;
}

//$("#gorevler").html(tabloyuAl());
var _json = [];
function gorevEkle(_gorevAdi, _atanan, _tarih) {
    var yeniId = yeniIdAl(_json);
    _json.push({
        id: yeniId,
        gorevAdi: _gorevAdi,
        atanan: _atanan,
        bitisTarihi: _tarih
    });
    $("#gorevler").html(tabloyuAl(_json));
}

function yeniIdAl(_obj) {
    if (!_obj.length > 0) { return 1 };
    var tumIdleriGetir = _obj.map(obj =>  obj.id );
    return Math.max(...tumIdleriGetir) + 1;
}

$(".islem_btn").click(function () {
    alert($(this).attr("data-val").val());
})


