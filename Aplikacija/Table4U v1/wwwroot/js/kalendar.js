$(".dugme-u-kalendaru").click(function obojiKlik(evt){
  var clicked = evt.target;
  var currentID = clicked.id || "No ID!";
  var check = document.getElementById('checkForma');
  var mesecText = document.getElementById('monthAndYear');
  var niz = mesecText.innerHTML.split(" ");
  var mesec = niz[0];
  var godina = niz[1];
  var podaci = document.getElementById('proba').value;

  $('#slobodniTermini').empty();
  var selekt = document.getElementById('slobodniTermini');
  var opcija1 = document.createElement("option");
  opcija1.appendChild( document.createTextNode("Time"));
  opcija1.value="Time";
  selekt.appendChild(opcija1);

  //samo ako je unchecked onda se upisuju automatski podaci u liste prilikom klika na datum
  if(check.checked==false)
  {
    var selekt = document.getElementById('dan');
    selekt.value=parseInt(currentID);
    var selekt1 = document.getElementById('mesec');
    selekt1.value=mesec;
    var selekt2 = document.getElementById('godina');
    selekt2.value=godina;
    var inp = document.getElementById('danIn');
    inp.value=parseInt(currentID);
    var inp1 = document.getElementById('mesIn');
    inp1.value=selekt1.selectedIndex;
    var inp2 = document.getElementById('godIn');
    inp2.value=godina;
  }

  if(check.checked==false)
  {
    var d = new Date();
    var selekt3 = document.getElementById('godina');
    if(parseInt(godina) < d.getFullYear() || parseInt(godina) > d.getFullYear())
    {
      selekt3.parentElement.querySelector(".error2").style.visibility="visible";
      selekt3.parentElement.querySelector(".error2").style.display="block";
    }
    else
    {
      selekt3.parentElement.querySelector(".error2").style.visibility="hidden";
    }
    selektError1('mesec');
    selektError2('dan');
  }

  //svima se dodeli bela boja, ako je checked onda se pri kliku opet dodeli bela boja inace plava
  $('.dugme-u-kalendaru').each(function(idx, cell) {
    cell.style.backgroundColor = '#fff';
  });

  //zatim se oboje dogadjaji
  obojiDogadjaje();
  
  //ako je u pitanju mesec pre trenutnog, ne pribavljaju se podaci, pa se zato ispituje
  if(podaci!="")
  {
    var nizDog = podaci.split("|");
    var nizVremena = nizDog[0].split(",");
    var nizVrste = nizDog[1].split(",");
    var nizOpisa = nizDog[2].split(",");
    var nizStart = nizDog[3].split(",");
    var nadjen = 0;
    var index = 0;
    //ako se klikne na neki dogadjaj da izbaci informacije o dogadjaju, do -1 da bi se izbegao poslednji el " "
    for(var i=0;i<(nizVremena.length)-1;i++){
      if(currentID==nizVremena[i]){
        nadjen=1;
        index=i;
      }
    }
  
    if(nadjen==1){
      $(".FormaDogadjaj").css("display","block");
      $(".tipDog").text("Type: " + nizVrste[index+1]);
      $(".opisDog").text("Description: " + nizOpisa[index+1]);
      $(".startDog").text("Start At: " + nizStart[index+1]);
    }
    else
      $(".FormaDogadjaj").css("display","none");
  }
  
  if(check.checked==true)
  { 
    if(!clicked.style.backgroundColor == '#5BBD50')
      clicked.style.backgroundColor = '#fff';
  }
  else{
    clicked.style.backgroundColor = '#919191';
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
  }
});