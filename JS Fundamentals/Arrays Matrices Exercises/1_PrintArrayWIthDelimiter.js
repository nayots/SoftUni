function printArrayWithDelimiter(params) {
    console.log(params.join(params.pop()));
}

printArrayWithDelimiter(["One","Two","Three","Four","Five","-"])