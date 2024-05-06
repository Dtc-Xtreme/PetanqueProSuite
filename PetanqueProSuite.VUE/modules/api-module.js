import axios from 'axios';

function GetAllLicenses() {
    try {
        axios.get('https://localhost:44362/License')
            .then(response => {
                console.log(response.data);
            });
    } catch (error) {
        console.error(error);
    }
}

function DeleteLicense() {
    alert("License is deleted!");
}

export default {
    GetAllLicenses,
    DeleteLicense
}