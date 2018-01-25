function magicMatrices(matrix) {
    let reference = matrix[0].map(Number).reduce((a,b) => a+b);
    let isMagic = true;
    for (let i = 0; i < matrix.length; i++) {
        let sum = matrix[0].map(Number).reduce((a,b) => a+b);
        if (sum !== reference) {
            isMagic = false;
            console.log(isMagic);
            return;
        }    
    }
    for (let i = 0; i < matrix[0].length; i++) {
        let sum = 0;
        for (let l = 0; l < matrix.length; l++) {
            sum += matrix[i][l];            
        }
        matrix[0].map(Number).reduce((a,b) => a+b);
        if (sum !== reference) {
            isMagic = false;
            console.log(isMagic);
            return;
        }    
    }
    console.log(isMagic);
}