function attachEvents() {
    const baseUrl = "https://baas.kinvey.com/appdata/kid_rkNY0nLqf/";
    const base64auth = btoa("peter:p");
    const authHeaders = {
        "Authorization": "Basic " + base64auth
    };
    $("#btnLoadPosts").click(loadPosts);
    $("#btnViewPost").click(viewComments);


    async function loadPosts() {
        let posts = await $.ajax({
            method: "GET",
            url: baseUrl + "posts",
            headers: authHeaders
        });
        let postsEle = $("#posts");
        postsEle.empty();
        for (const p of posts) {
            postsEle.append($(`<option value="${p._id}">${p.title}</option>`));
        }
    }

    async function viewComments() {
        let selectedPostId = $("#posts option:selected").val();

        if (!selectedPostId) {
            return;
        }
        let post = await $.ajax({
            method: "GET",
            url: baseUrl + `posts/${selectedPostId}`,
            headers: authHeaders
        });
        let comments = await $.ajax({
            method: "GET",
            url: baseUrl + `comments/?query={"post_id":"${selectedPostId}"}`,
            headers: authHeaders
        });
        $("#post-title").text(post.title);
        $("#post-body").empty().append(post.body);
        let commentsList = $("#post-comments");
        commentsList.empty();
        for (const c of comments) {
            commentsList.append($(`<li>${c.text}</li>`));
        }
    }
}