var i=0;
function tikla(){
    let kutu = document.querySelector(".teminat-2")
        
        if (i==0) {
            kutu.style.display="block";
            i=1;   
         }  
         else{
            kutu.style.display="none" ;
            i=0; 
        }
    
}