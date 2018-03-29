function attachEvents() {
    const baseUrl = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students";
    const auth = `Basic ${btoa("guest:guest")}`;
    const requestHeaders = {
        "Authorization": auth,
        "Content-type": "application/json"
    }


    $(loadStudents());
    $("#add").click(addStudent);

    async function loadStudents() {
        console.log("IN loads");

        let students = await $.ajax({
            method: "GET",
            url: baseUrl,
            headers: requestHeaders
        });
        console.log(students);

        console.log("After await");

        $("#results tr:not(:first-child)").remove();
        let table = $("#results");
        let orderedStudents = students.sort((a, b) => {
            return Number(a.ID) - Number(b.ID);
        })
        for (const student of orderedStudents) {
            table.append($(`<tr>`)
                .append($(`<td>${student.ID}</td>`))
                .append($(`<td>${student.FirstName}</td>`))
                .append($(`<td>${student.LastName}</td>`))
                .append($(`<td>${student.FacultyNumber}</td>`))
                .append($(`<td>${student.Grade}</td>`)))
        }
    }

    function addStudent() {
        let [ID, FirstName, LastName, FacultyNumber, Grade] = $("#studentData input").map((i, item) => $(item).val());

        if (ID, FirstName, LastName, FacultyNumber, Grade) {
            $("#studentData input").val("");
            let data = {
                ID: Number(ID),
                FirstName,
                LastName,
                FacultyNumber,
                Grade: Number(Grade)
            }

            $.ajax({
                method: "POST",
                url: baseUrl,
                headers: requestHeaders,
                data: JSON.stringify(data)
            }).then(() => {
                loadStudents();
            })
        }
    }
}