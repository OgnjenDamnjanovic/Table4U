$(".dugme-u-kalendaru").click(function(evt){
    var clicked = evt.target;
    var currentID = clicked.id || "No ID!";
    console.log(currentID);
    var a = document.querySelector(".datumDan");
    a.innerHTML=currentID;
    var selekt = document.getElementById('dan');
    selekt.value=parseInt(currentID);
    $('td').each(function(idx, cell) {
        cell.style.backgroundColor = '#fff';
      });
      clicked.style.backgroundColor = '#0093e0';
});
