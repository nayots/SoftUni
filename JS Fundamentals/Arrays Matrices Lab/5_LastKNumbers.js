function lastK(n, k) {
    let arr = [1];
    for (let i = 1; i < n; i++) {
        let res = arr.slice(Math.max(0,i-k),i).reduce((a,b) => a + b);
        arr.push(res);
    }

    console.log(arr.join(" "));
}

// lastK(6,3);
// lastK(8,2);