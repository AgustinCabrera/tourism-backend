const SuggestionsComponent = ({ suggestions, onSelectAttraction }) => {
    return (
        <div>
            {suggestions.map(attraction => (
                <div key={attraction.id}>
                    <h3>{attraction.name}</h3>
                    <p>{attraction.description}</p>
                    <button onClick={() => onSelectAttraction(attraction)}>
                        Add to Itinerary
                    </button>
                </div>
            ))}
        </div>
    );
};
