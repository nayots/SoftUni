function loadCommits() {
    let username = $("#username").val();
    let repo = $("#repo").val();
    let commitsUl = $("#commits");
    if (username && repo) {
        commitsUl.empty();
        $.ajax({
                method: "GET",
                url: `https://api.github.com/repos/${username}/${repo}/commits`
            })
            .then((result) => {
                for (const r of result) {
                    addToUl(`${r.commit.author.name}: ${r.commit.message}`);
                }
            }).catch((err) => {
                addToUl(`Error: ${err.status} (${err.statusText})`);
            })
    }

    function addToUl(msg) {
        commitsUl.append($(`<li>${msg}</li>`));
    }
}