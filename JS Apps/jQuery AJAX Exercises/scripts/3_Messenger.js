function attachEvents() {
    const url = "https://messenger-745d5.firebaseio.com/messenger/.json";

    function sendMsg() {
        let authorName = $("#author").val();
        let msgContent = $("#content").val();
        if (authorName && msgContent) {
            let data = {
                author: authorName,
                content: msgContent,
                timestamp: Date.now()
            }
            $.ajax({
                method: "POST",
                url: url,
                data: JSON.stringify(data)
            }).then((res) => {
                refresh();
            }).catch((err) => console.log(err));
        }
    }

    function refresh() {
        $.ajax({
            method: "GET",
            url: url
        }).then((res) => {
            let orderedResults = Array.from(Object.keys(res).map(k => res[k])).sort((a, b) => {
                return a.timestamp - b.timestamp;
            });
            let result = orderedResults.map(i => `${i.author}: ${i.content}`).join("\n");
            $("#messages").text(result);
        })
    }

    $("#submit").click(sendMsg);
    $("#refresh").click(refresh);
    refresh();
}