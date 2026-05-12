const apiUrl = "http://localhost:5107/api/ActivityManager";

async function loadData() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error("Failed to LOAD.");

        const datas = await response.json();
        let html = "";

        console.log(datas);

        datas.forEach(activity => {
            html += `
                <tr>
                    <td>${activity.taskName}</td>
                    <td>${activity.duration}</td>
                    <td>${activity.priority}</td>
                    <td>${activity.isFinished ? "Igen" : "Nem"}</td>
                    <td><button onclick="del(${activity.id})">Törlés</td>
                </tr>
            `;
        });

        document.getElementById("tableBody").innerHTML = html;


    } catch (error) {
        console.log("Error: ", error);

    }
}

document.getElementById("addForm").onsubmit = async function (event) {
    event.preventDefault();

    const newActivity = {
        TaskName: document.getElementById("taskName").value,
        Duration: parseInt(document.getElementById("duration").value),
        Priority: parseInt(document.getElementById("priority").value),
        IsFinished: document.getElementById("isFinished").checked,
    }

    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newActivity)
        });

        if (!response.ok) throw new Error("Failed to ADD.")
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
        if (!response.ok) throw new Error("Failed to DELETE.");

        loadData();

    } catch (error) {
        console.log("Error: ", error);

    }
}

loadData();