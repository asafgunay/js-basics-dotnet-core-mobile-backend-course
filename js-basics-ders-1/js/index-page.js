document.getElementById("tabela")
.innerHTML=
"hoşça kal";

function tabelaClicked(){
    alert("butona tıklandı!!!")
}

document.getElementById("tabela-btn").onclick = function(){

    alert("buton 2'ye tıklandı");
}



// document.getElementById("tabela")
// .style
// .display="none";

var arabalar = ["mercedes", "audi","renault","fiat"];

var i;
for(i=0; i<arabalar.length; i++){
    if(arabalar[i]=="audi"){
        arabalar[i]="bmw"
    }
    console.log(arabalar[i]);
}








