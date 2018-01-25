function solveSequence(params) {
    let bInd = null;
    let res = [];
    if (params.length > 0) {
        res = params.map(Number).filter((ele, ind, ar) => {
            if (ele >= bInd) {
                bInd = ele;
                return true;
            }
            return false;
        });

    }
    console.log(res.join("\n"));
}

// solveSequence([1,3,8,4,10,12,3,2,24])
// solveSequence([0])
// solveSequence([1,2,3,4])
// solveSequence([1,1,1]);
// solveSequence([0,0,0])
// solveSequence([87, 88, 91, 10, 22, 9, 92, 94, 33, 21, 50, 41, 60, 80]);
// solveSequence(['1','3','8','4','10','12','3','3','24']);
// solveSequence(['20','3','2','15','6','1'])