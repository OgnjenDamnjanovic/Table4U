function getTime(vr){
    var lokalId = document.getElementById('idIn').value;
    var dan = document.getElementById('dan').value;
    var mesec = document.getElementById('mesec').selectedIndex;
    var godina = document.getElementById('godina').value;
    var datum = new String(godina+"-"+mesec+"-"+dan);

    $('#slobodniTermini').empty();
    var selekt = document.getElementById('slobodniTermini');

    var opcija1 = document.createElement("option");
    opcija1.appendChild( document.createTextNode("Time"));
    opcija1.value="Time";
    selekt.appendChild(opcija1);

    //puni listu
    var cetvrtSat = ["00","15","30","45"];
    for(var i=12;i<24;i++){
        for(var j=0;j<4;j++){
            var opcija = document.createElement("option");
            opcija.appendChild( document.createTextNode(i+":"+cetvrtSat[j]));
            opcija.value=i+":"+cetvrtSat[j];
            selekt.appendChild(opcija);
        }
    }

    //funkcija koja izbacuje iz liste termina termine dva sata pre dogadjaja i sve termine posle dogadjaja
    var podaci = document.getElementById('proba').value;
    var niz = podaci.split("|");
    if(podaci!="|,|,|,|" && podaci!="")
    {
      var nizDatumi = niz[0].split(",");
      var index=0;
      var nadjen=0;
      for(var i=0; i<nizDatumi.length-1;i++)
      {
        if(parseInt(nizDatumi[i])==dan){
            nadjen=1;
            index=i;
        }
      }
      if(nadjen==1)
      {
        var nizVremena = niz[3].split(",");
        var vreme = nizVremena[index+1];
        var broj = 0;
        for(var j=1;j<selekt.options.length;j++)
        {
            if(vreme===selekt.options[j].value)
                broj = j;
        }
        if(broj!=0)
        {
            for(var i=broj+1;i<selekt.options.length;i++)
                selekt.options[i].disabled=true;
            for(var i=broj-1;i>=broj-7;i--)
                selekt.options[i].disabled=true;
        }
      }
    }

    //da obrise 23:45
    selekt.options.remove(selekt.options.length-1);
    if(document.getElementById('dan').selectedIndex>=1 && mesec>=1 && document.getElementById('godina').selectedIndex>=1)
    {
        $.ajax({
            type: "GET",
            url: '/Object?Id='+lokalId+'&handler=Proveri',
            beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: {sto:vr, id:lokalId, date:datum},
            success: function (response) {
                if(response.length!=0){
                    var selekt = document.getElementById('slobodniTermini');
                    for(var i=0;i<response.length;i++)
                    {
                        for(var j=1;j<selekt.options.length;j++)
                        {
                            if(response[i]===selekt.options[j].value)
                            {
                                selekt.options[j].disabled=true;
                            }
                        }
                    }
                }
            }
        })
    }
}