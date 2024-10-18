window.completePayment = async function (clientSecret) {
    const stripe = Stripe('pk_live_51Q5A8jFxTXUi7K7UCBW8h4mtVxqM0MRaxQ6vF0s6P85n3ppncoC4xDzgRavqROYBEMMvFSpjW91t5rM3aFDcslwG00dsfyVBhG');  // Your public Stripe key

    const elements = stripe.elements();
    const card = elements.create('card');
    card.mount('#card-element');

    const { error, paymentIntent } = await stripe.confirmCardPayment(clientSecret, {
        payment_method: {
            card: card,
            billing_details: {
                name: 'John Doe',
            },
        },
    });

    if (error) {
        console.error('Payment failed:', error.message);
    } else {
        console.log('Payment successful:', paymentIntent.status);
    }
};