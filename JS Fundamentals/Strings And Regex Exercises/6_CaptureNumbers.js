function captureNumbers(params) {

    let nums = [];
    let pattern = /(\d+)/g;

    let text = params.join(" ");
    nums = text.match(pattern);

    console.log(nums.join(" "));
}

// captureNumbers(["Let’s go11!!!11!", "Okey!1!"])