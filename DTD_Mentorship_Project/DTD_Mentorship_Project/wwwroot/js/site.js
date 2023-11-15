// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Fetch city, state, and zip code data from ASP.NET API
fetch('/api/location/cities')
    .then(response => response.json())
    .then(data => {
        const cityDropdown = document.getElementById('City');
        // Populate city dropdown
        data.forEach(city => {
            const option = document.createElement('option');
            option.text = city.name;
            option.value = city.name;
            cityDropdown.add(option);
        });
    })
    .catch(error => console.error(error));

fetch('/api/location/states')
    .then(response => response.json())
    .then(data => {
        const stateDropdown = document.getElementById('State');
        // Populate state dropdown
        data.forEach(state => {
            const option = document.createElement('option');
            option.text = state.name;
            option.value = state.name;
            stateDropdown.add(option);
        });
    })
    .catch(error => console.error(error));

fetch('/api/location/zipcodes')
    .then(response => response.json())
    .then(data => {
        const zipDropdown = document.getElementById('Zip');
        // Populate zip code dropdown
        data.forEach(zipCode => {
            const option = document.createElement('option');
            option.text = zipCode.code;
            option.value = zipCode.code;
            zipDropdown.add(option);
        });
    })
    .catch(error => console.error(error));

// Handle form submission
const form = document.getElementById('regularForm'); // Replace 'yourFormId' with the actual ID of your form
form.addEventListener('submit', async (event) => {
    event.preventDefault();

    const formData = new FormData(form);
    const response = await fetch('/api/validate', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        // Form submission successful, redirect to success page
        window.location.href = '/SuccessPage'; // Replace 'SuccessPage' with the actual success page route
    } else {
        // Form validation failed, display errors to the user
        const errorData = await response.json();
        // Handle error data and display validation messages to the user
        console.log(errorData);
    }
});