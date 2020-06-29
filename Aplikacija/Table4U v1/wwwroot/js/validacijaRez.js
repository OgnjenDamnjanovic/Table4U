function ValidacijaRez(){
    if(selektGodina('godina') || selektError1('mesec') || selektError2('dan') || selektError('brMesta') || selektError3('slobodniTermini'))
        return false;
}

var el = document.getElementById('dan');
el.onfocus=function(){
    this.onblur=()=>{selektError2('dan');}
}
el.onchange=function(){
    selektError2('dan');
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
}

var el1 = document.getElementById('mesec');
el1.onfocus=function(){
    this.onblur=()=>{selektError1('mesec');}
}
el1.onchange=function(){
    selektError1('mesec');
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
}

var el2 = document.getElementById('godina');
el2.onfocus=function(){
    this.onblur=()=>{selektGodina('godina');}
}
el2.onchange=function(){
    selektGodina('godina');
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
}

var el3 = document.getElementById('slobodniTermini');
el3.onfocus=function(){
    this.onblur=()=>{selektError3('slobodniTermini');}
}
el3.onchange=function(){
    selektError3('slobodniTermini');
}

var el4 = document.getElementById('brMesta');
el4.onfocus=function(){
    this.onblur=()=>{selektError('brMesta');}
}

function selektError(selektId)
{   
    var el = document.getElementById(selektId);
    if(el.selectedIndex == 0)
    {
        el.parentElement.querySelector(".error2").style.visibility="visible";
        el.parentElement.querySelector(".error2").style.display="block";
        return true;
    }
    else
    {
        el.parentElement.querySelector(".error2").style.visibility="hidden";
        return false;
    }
}

function selektError1(selektId)
{
    var d = new Date();
    var el = document.getElementById(selektId);
    var el1 = document.getElementById('godina');
    if(el.selectedIndex == 0 || ((el.selectedIndex)-1 < d.getMonth() && parseInt(el1.value)==d.getFullYear()))
    {
        el.parentElement.querySelector(".error2").style.visibility="visible";
        el.parentElement.querySelector(".error2").style.display="block";
        return true;
    }
    else if(parseInt(el1.value)>d.getFullYear())
    {
        el.parentElement.querySelector(".error2").style.visibility="hidden";
        return false;
    }
    else
    {
        el.parentElement.querySelector(".error2").style.visibility="hidden";
        return false;
    }
}

function selektError2(selektId)
{
    var d = new Date();
    var el = document.getElementById(selektId);
    var el1 = document.getElementById('mesec');
    if(el.selectedIndex == 0 || (el.selectedIndex < d.getDate() && (el1.selectedIndex)-1==d.getMonth()))
    {
        el.parentElement.querySelector(".error2").style.visibility="visible";
        el.parentElement.querySelector(".error2").style.display="block";
        return true;
    }
    else
    {
        el.parentElement.querySelector(".error2").style.visibility="hidden";
        return false;
    }
}

function selektError3(selektId)
{
    var d = new Date();
    var el = document.getElementById(selektId);
    var el1 = document.getElementById('mesec');
    var el2 = document.getElementById('dan');
    var el3 = document.getElementById('godina');
    if((el1.selectedIndex)-1 == d.getMonth() && el2.selectedIndex == d.getDate() && el3.value == d.getFullYear())
    {
        var niz = el.value.split(":");
        if(parseInt(niz[0]) < d.getHours())
        {
            el.parentElement.querySelector(".error2").style.visibility="visible";
            el.parentElement.querySelector(".error2").style.display="block";
            return true;
        }
        else if(parseInt(niz[0]) == d.getHours())
        {
            if(parseInt(niz[1]) < d.getMinutes())
            {
                el.parentElement.querySelector(".error2").style.visibility="visible";
                el.parentElement.querySelector(".error2").style.display="block";
                return true;
            }
            else
            {
                el.parentElement.querySelector(".error2").style.visibility="hidden";
                return false;
            }
        }
        else if(el.selectedIndex == 0)
        {
            el.parentElement.querySelector(".error2").style.visibility="visible";
            el.parentElement.querySelector(".error2").style.display="block";
            return true;
        }
        else
        {
            el.parentElement.querySelector(".error2").style.visibility="hidden";
            return false;
        }
    }
    else if(el.selectedIndex == 0)
    {
        el.parentElement.querySelector(".error2").style.visibility="visible";
        el.parentElement.querySelector(".error2").style.display="block";
        return true;
    }
    else
    {
        el.parentElement.querySelector(".error2").style.visibility="hidden";
        return false;
    }
}

function selektGodina(selektId)
{   
    var d = new Date();
    var el = document.getElementById(selektId);
    if(el.selectedIndex == 0)
    {
        el.parentElement.querySelector(".error2").style.visibility="visible";
        el.parentElement.querySelector(".error2").style.display="block";
        return true;
    }
    else
    {
        el.parentElement.querySelector(".error2").style.visibility="hidden";
        return false;
    }
}
