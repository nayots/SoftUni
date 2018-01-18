function primerChecker(n) {
    let primeCheck = true;
    if (n === 0 || n === 1)
    {
        primeCheck = false;
    }
    else
    {
        for (let i = 2; i <= Math.sqrt(n); i++)
        {
            if (n % i === 0)
            {
                primeCheck = false;
                break;
            }
        }
    }
    console.log(primeCheck && (n > 0));
}

primerChecker(0);
// primerChecker(8);
// primerChecker(81);