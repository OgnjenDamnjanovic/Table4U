$(document).ready(function prikazFormi(){
    $("#Prikazi").click(function(){
        $("#Forma").css("display","block");
        $("#Glavni").css("display","block");
        $("#Prikazi1").css("display","none");
        $("#Sakrij").css("display","block");
    });
    $("#Sakrij").click(function(){
        $("#Forma").css("display","none");
        $("#Glavni").css("display","none");
        $("#Prikazi1").css("display","block");
        $("#Sakrij").css("display","none");
        $(".FormaDogadjaj").css("display","none");
    });
    $("#dodajRec").click(function(){
        $("#FormaRec").css("display","block");
        $("#dodajRec").css("display","none");
        if($(window).width()<=1002)
            $("#dodajRecInfo").css("display","block");
    });
    $("#otkaziRec").click(function(){
        $("#FormaRec").css("display","none");
        $("#dodajRec").css("display","block");
        $("#dodajRecInfo").css("display","none");
    });
    
});