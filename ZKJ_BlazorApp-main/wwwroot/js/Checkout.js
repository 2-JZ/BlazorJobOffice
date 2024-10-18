//var stripe = Stripe('pk_live_51Q5A8jFxTXUi7K7UCBW8h4mtVxqM0MRaxQ6vF0s6P85n3ppncoC4xDzgRavqROYBEMMvFSpjW91t5rM3aFDcslwG00dsfyVBhG');

let stripe;
let elements;
let cardElement;

async function initializeStripe() {
    // Inicjalizacja Stripe
    stripe = Stripe('pk_live_51Q5A8jFxTXUi7K7UCBW8h4mtVxqM0MRaxQ6vF0s6P85n3ppncoC4xDzgRavqROYBEMMvFSpjW91t5rM3aFDcslwG00dsfyVBhG');

    // Inicjalizacja elements
    elements = stripe.elements();

    // Utworzenie elementu karty
    cardElement = elements.create('card');
    cardElement.mount('#card-element');

    // Obsługa zmian w elemencie karty
    cardElement.on('change', function (event) {
        const displayError = document.getElementById('card-errors');
        if (event.error) {
            displayError.textContent = event.error.message;
        } else {
            displayError.textContent = '';
        }
    });
}

async function processPayment() {
    // Logika przetwarzania płatności
    const { paymentMethod, error } = await stripe.createPaymentMethod({
        type: 'card',
        card: cardElement,
    });

    if (error) {
        // Obsługa błędów
        console.error(error);
        return;
    }

    // Wywołanie metody C# w Blazor
    DotNet.invokeMethodAsync('BlazorApp', 'ProcessPayment', paymentMethod.id)
        .then(response => {
            console.log("Payment processed successfully", response);
        })
        .catch(err => {
            console.error("Error processing payment", err);
        });
}

