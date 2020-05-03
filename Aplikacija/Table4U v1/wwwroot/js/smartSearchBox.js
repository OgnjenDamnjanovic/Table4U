function selectToArray(queryStringSelect)
{
    let array=new Array();
    document.querySelectorAll(queryStringSelect+" option").forEach(option =>
    {
        array.push(option.value);

    });
    return array;

}


document.addEventListener("DOMContentLoaded",function(){

let listaCity=selectToArray("#select-hidden-cityDistinct");

 $( ".navmain .location" ).autocomplete({
  source: listaCity    
     }
 );

let listaRestaurant=selectToArray("#select-hidden-cityRestaurant");

let listaRestaurantNaziv=new Array();
listaRestaurant.map(rest=>{

    listaRestaurantNaziv.push(JSON.parse(rest)["naziv"]);

    })
    

$(".navmain .restaurant").autocomplete({
    source: listaRestaurantNaziv,
    }
);
});



document.querySelector(".navmain .location").onfocus=function(){

    this.value ="";
    this.style.color="rgb(122,122,122)";
    this.style.fontWeight="600";
}

document.querySelector(".navmain .location").onblur =function(){ 

    if(this.value=="")
    {   
        let listaRestaurant=selectToArray("#select-hidden-cityRestaurant");
        let listaRestaurantNaziv=new Array();
            listaRestaurant.map(rest=>{
             listaRestaurantNaziv.push(JSON.parse(rest)["naziv"]);
        
    });

    $(".navmain .restaurant").autocomplete({
    source: listaRestaurantNaziv,
    }
    );

        this.value="Niš";
        this.style.color="rgb(192,192,192)";
        this.style.fontWeight="400";
        this.onfocus=function()
        {
        this.value="";
        this.style.color="rgb(122,122,122)";
        this.style.fontWeight="600";
        }
    }
    else
    {
    this.onfocus=function(){
        //do nothing
      }
      

      let listaRestaurant=selectToArray("#select-hidden-cityRestaurant");
      let listaRestaurantNaziv=new Array();
      let listaRestaurantGrad=new Array();
            
      listaRestaurant.map(rest=>{
            
        listaRestaurantNaziv.push(JSON.parse(rest)["naziv"]);
        listaRestaurantGrad.push(JSON.parse(rest)["grad"]);
 

    });
    let listaFiltered=new Array();
    listaRestaurantGrad.forEach((el,index)=>{
        if(el==this.value)
        listaFiltered.push(listaRestaurantNaziv[index]);
        }
        );
    console.log(listaFiltered);
    $( ".navmain .restaurant" ).autocomplete("option", "source", listaFiltered );

}
}



 document.querySelector(".navmain .restaurant").onblur =function(){
    if(this.value=="")
    {
        let listaCity=selectToArray("#select-hidden-cityDistinct");

        $( ".navmain .location" ).autocomplete({
        source: listaCity    
         } );
        this.value="Meze";
        this.style.color="rgb(192,192,192)";
        this.style.fontWeight="400";
        this.onfocus=function(){
        this.value="";
        this.style.color="rgb(122,122,122)";
        this.style.fontWeight="600";
        }
        
    }
    else
    {
    this.onfocus=function(){
        //do nothing
      }
      
      let listaRestaurant=selectToArray("#select-hidden-cityRestaurant");
      let listaRestaurantNaziv=new Array();
      let listaRestaurantGrad=new Array();
            
      listaRestaurant.map(rest=>{
            
        listaRestaurantNaziv.push(JSON.parse(rest)["naziv"]);
        listaRestaurantGrad.push(JSON.parse(rest)["grad"]);
 

    });
    let listaFiltered=new Array();
    listaRestaurantNaziv.forEach((el,index)=>{
        if(el==this.value)
        listaFiltered.push(listaRestaurantGrad[index]);
        }
        );
    console.log(listaFiltered);
    $( ".navmain .location" ).autocomplete("option", "source", listaFiltered );
    }
}
document.querySelector(".navmain .restaurant").onfocus=function(){

    this.value ="";
    this.style.color="rgb(122,122,122)";
    this.style.fontWeight="600";
}

