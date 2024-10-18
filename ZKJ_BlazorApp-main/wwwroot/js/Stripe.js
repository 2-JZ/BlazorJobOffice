let stripe;
let cardElement;

function initializeStripe() {
    // Use your actual publishable key
    stripe = Stripe('pk_test_51Q5A8jFxTXUi7K7UOqd8oaQKDvasqIbsuQYkIOOSBZNJ4wfCwQ4EnxxYjCATlCulA35DfjKQh06W48KBIg5KT72J00msOsNOdd');
    const elements = stripe.elements();
    cardElement = elements.create('card');
    cardElement.mount('#card-element');

    // Listen for changes in the card element and update the "Pay" button's state
    cardElement.on('change', function (event) {
        const displayError = document.getElementById('card-errors');
        const payButton = document.querySelector('button');

        if (event.error) {
            displayError.textContent = event.error.message;
            payButton.disabled = true; // Disable button on error
        } else {
            displayError.textContent = '';
            payButton.disabled = !event.complete; // Enable button if input is complete
        }
    });
}

function monitorCardInputValidity(dotNetHelper) {
    cardElement.on('change', function (event) {
        if (event.complete) {
            // Invoke the instance method to enable the pay button
            dotNetHelper.invokeMethodAsync('EnablePayButton');
        }
    });
}

async function completePayment(dotnetHelper) {
    try {
        // Create the PaymentMethod
        const { paymentMethod, error: paymentMethodError } = await stripe.createPaymentMethod({
            type: 'card',
            card: cardElement
        });

        if (paymentMethodError) {
            console.error("PaymentMethod error:", paymentMethodError.message);
            document.getElementById('card-errors').textContent = paymentMethodError.message;
            return null; // Stop here on error
        }

        console.log("PaymentMethod created:", paymentMethod);

        // Return the paymentMethod.id for the Blazor component
        return paymentMethod.id;

    } catch (error) {
        console.error('Error in completePayment:', error);
        document.getElementById('card-errors').textContent = 'An error occurred during payment. Please try again.';
        return null; // Return null on error
    }
}

// Expose functions to Blazor
window.initializeStripe = initializeStripe;
window.completePayment = completePayment;
window.monitorCardInputValidity = monitorCardInputValidity;
