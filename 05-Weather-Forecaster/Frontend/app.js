const apiUrl = "http://localhost:5222/api/WeatherForecast";

async function loadData() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error("Failed to load data.");

        const datas = await response.json();
        let html = "";

        datas.forEach(forecast => {
            html += `
                <tr>
                    <td>${forecast.date}</td>
                    <td>${forecast.degree}</td>
                    <td>${forecast.wind}</td>
                    <td>${forecast.weatherType}</td>
                    <td><button onclick="del(${forecast.id})">Törlés</td>
                </tr>
            `;
        });

        document.getElementById("tableBody").innerHTML = html;

        const stats = await fetch("http://localhost:5222/api/WeatherForecast/max-degree");
        if (stats.ok) {
            const data = await stats.text();
            document.getElementById("max-degree").innerText = `Eddigi hőségrekord: ${data} C°`;
        }

        console.log(datas);

    } catch (error) {

    }
}

document.getElementById("addForm").onsubmit = async function (event) {
    event.preventDefault();

    const newForecast = {
        Date: document.getElementById("date").value,
        Degree: parseInt(document.getElementById("degree").value),
        Wind: parseInt(document.getElementById("wind").value),
        WeatherType: parseInt(document.getElementById("weatherType").value),
    }

    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newForecast)
        });
        if (!response.ok) throw new Error("Failed to ADD.");

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