arr1=["Ravi","Ram","Shyam"];
arr2=["shiv","krish","lakhan"];
k=0
for(i=0;i<=arr1.length;i++){
    if(i%2 !=0){
        arr1.splice(i,0,arr2[k])
        k++;
    }
}
console.log(arr1)