//popunjava broj dana u mesecu u odnosu na selektovan mesec iz liste
$('#mesec').change(function(){
    var broj =0;
    var index = $("#mesec").get(0).selectedIndex;
    if(index==2){
        broj = 28;
    }
    else if(index==4 || index==6 || index==9 || index==11){
        broj = 30;
    }
    else if(index==0){
        broj=0;
    }
    else{
        broj=31;
    }
    if(broj!=0)
    {
        $('#dan').empty();
        var selekt = document.getElementById('dan');
        var i=0;
        var opcija1 = document.createElement("option");
        opcija1.appendChild( document.createTextNode("Day") );
        opcija1.value="Day";
        selekt.appendChild(opcija1);
        for(i=1;i<=broj;i++)
        {
            var opcija = document.createElement("option");
            opcija.appendChild( document.createTextNode(i) );
            opcija.value = i; 
            selekt.appendChild(opcija);
        }
    }
    else{
        $('#dan').empty();
        var selekt = document.getElementById('dan');
        var opcija1 = document.createElement("option");
        opcija1.appendChild( document.createTextNode("Day") );
        opcija1.value="Day";
        selekt.appendChild(opcija1);
    }
});