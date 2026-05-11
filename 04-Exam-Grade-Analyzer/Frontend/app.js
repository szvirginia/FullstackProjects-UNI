const apiUrl = "http://localhost:5051/api/GradeAnalyzer";

async function loadData() {
    try {
        const response = await fetch(apiUrl);

        if (!response.ok) throw new Error("Failed to load!");

        const datas = await response.json();

        let html = "";

        datas.forEach(grade => {
            html += `
                <tr>
                    <td>${grade.name}</td>
                    <td>${grade.subject}</td>
                    <td>${grade.gradeType}</td>
                    <td><button onclick="del(${grade.id})">Törlés</td>
                </tr>
            `;
        });
        console.log(datas);

        document.getElementById("tableBody").innerHTML = html;


    } catch (error) {
        console.log("Error: ", error)
    }
}

document.getElementById("addForm").onsubmit = async function (event) {
    event.preventDefault();

    const newGrade = {
        Name: document.getElementById("name").value,
        Subject: document.getElementById("subject").value,
        GradeType: parseInt(document.getElementById("gradeType").value,
        )
    };

    console.log("Backendnek küldöm: " + JSON.stringify(newGrade));

    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newGrade)
        })

        if (!response.ok) throw new Error("Fail to ADD!");
        loadData();

        document.getElementById("addForm").reset();

    } catch (error) {
        console.log("Error: ", error);
    }


}

async function del(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) throw new Error("Fail to DELETE!");

        loadData();

    } catch (error) {
        console.log("Error: ", error)
    }
}

loadData();