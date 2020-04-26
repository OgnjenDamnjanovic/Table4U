$('#checkForma').click(function(){
    var dan = document.getElementById('dan');
    var mesec = document.getElementById('mesec');
    var godina = document.getElementById('godina');
    if (this.checked == false){
        dan.disabled=true;
        mesec.disabled=true;
        godina.disabled=true;
        dan.value="Day";
        mesec.value="Month";
        godina.value="Year";
      } else {
        dan.disabled=false;
        mesec.disabled=false;
        godina.disabled=false;
        $(".dugme-u-kalendaru").each(function() {
            this.style.backgroundColor = '#fff';
          });
        dan.value="Day";
        mesec.value="Month";
        godina.value="Year";
      }
});