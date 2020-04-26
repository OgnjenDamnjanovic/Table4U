//skripta za kalendar na object strani.. kada se klikne na datum u kalendaru da promeni boju i da popuni liste sa vrednostima(na datum koji se klikne)
$(".dugme-u-kalendaru").click(function(evt){
    var clicked = evt.target;
    var currentID = clicked.id || "No ID!";
    var check = document.getElementById('checkForma');
    //izvlaci se trenutna godina i mesec
    var mesecText = document.getElementById('monthAndYear');
    var niz = mesecText.innerHTML.split(" ");
    var mesec = niz[0];
    var godina = niz[1];
    //samo ako je unchecked onda se upisuju automatski podaci u liste prilikom klika na datum
    if(check.checked==false)
    {
      var selekt = document.getElementById('dan');
      selekt.value=parseInt(currentID);
      var selekt1 = document.getElementById('mesec');
      selekt1.value=mesec;
      var selekt2 = document.getElementById('godina');
      selekt2.value=godina;
    }
    //svima se dodeli bela boja, ako je checked onda se pri kliku opet dodeli bela boja inace plava
    $('td').each(function(idx, cell) {
        cell.style.backgroundColor = '#fff';
      });
      if(check.checked==true)
      {
        clicked.style.backgroundColor = '#fff';
      }
      else{
        clicked.style.backgroundColor = '#919191';
      }
});
