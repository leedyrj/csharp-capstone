
export default class APImanager {


    static getAllReports = () => {
        return fetch("https://localhost:5000/api/reports", {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(a => a.json())
    }

    static getOneReport = (id) => {
        return fetch(`https://localhost:5000/api/reports/${id}`, {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(res => res.json())
    }

    static postExpense = (id, description, amount, expenseDate, location, expenseTypeId) => {
        return fetch('https://localhost:5000/api/expenses'), {
            "method": "POST",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
            "body": JSON.stringify({
                "description": description,
                "amount": amount,
                "expenseDate": expenseDate,
                "expenseTypeId": expenseTypeId,
                "location": location,
                "reportid": id
            })
                .then(res => res.json())
        }
    }

    static getExpenseTypes = () => {
        return fetch('https://localhost:5000/api/expenseTypes', {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(res => {
                console.log("response in api manager", res)
                return res.json();
            })
    }
}

