function generateMatrix(n) {
    var total = n*n;
    var result= [];
 
    for(var i=0;i<n;i++) {
        var rs = [];
        for(var j=0;j<n;j++) {
            rs.push(0);
        }   
        result.push(rs);
    }
    
    var x=0;
    var y=0;
    var step = 0;
    for(var i=0;i<total;){
        while(y+step<n){
            i++;
            result[x][y]=i; 
            y++;
 
        }    
        y--;
        x++;
        
        while(x+step<n){
            i++;
            result[x][y]=i;
            x++;
        }
        x--;
        y--;
         
        while(y>=step){
            i++;
            result[x][y]=i;
            y--;
        }
        y++;
        x--;
        step++;
         
        while(x>=step){
            i++;
            result[x][y]=i;
            x--;
        }
        x++;
        y++;
    }
    return result.forEach(row => console.log(row.join(' ')));;
}