const ItineraryComponent = ({ itinerary, onRemoveAttraction }) => {
    return (
        <div>
            <h2>Your Itinerary</h2>
            {itinerary.attractions.map(attraction => (
                <div key={attraction.id}>
                    <h4>{attraction.name}</h4>
                    <p>{attraction.cost}</p>
                    <button onClick={() => onRemoveAttraction(attraction)}>
                        Remove
                    </button>
                </div>
            ))}
            <p>Total Cost: {itinerary.totalCost}</p>
            <p>Remaining Budget: {itinerary.remainingBudget}</p>
        </div>
    );
};
