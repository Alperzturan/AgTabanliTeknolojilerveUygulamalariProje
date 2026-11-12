document.addEventListener("DOMContentLoaded", ()=>{
    const searchInput = document.querySelector("input[type=search]")
    const checkboxes = document.querySelectorAll(".filter")
    const gameCards = document.querySelectorAll(".game-cards")

    if (gameCards.length === 0) return

    const filterGames = ()=>{
        const searchText = searchInput ? searchInput.value.trim().toLowerCase() : "";

        const activeFilters = {};
        checkboxes.forEach(cb => {
            if (cb.checked) {
                if (!activeFilters[cb.name]) activeFilters[cb.name] = [];
                activeFilters[cb.name].push(cb.value.toLowerCase());
            }
        });

        gameCards.forEach(card=>{
            const cardTitle = (card.dataset.title || "").toLowerCase()
            const matchesSearch = cardTitle.includes(searchText)

            let matchesFilters = true;
            for (const filterName in activeFilters) {
                const cardValue = (card.dataset[filterName] || "").toLowerCase();

                if (!activeFilters[filterName].includes(cardValue)) {
                    matchesFilters = false;
                    break;
                }
            }

            if (matchesFilters && matchesSearch) {
                card.classList.remove("d-none")
            }else {
                card.classList.add("d-none")
            }
        })
    }
    if (searchInput) {
        searchInput.addEventListener('input', filterGames);
    }
    
    checkboxes.forEach(cb => {
        cb.addEventListener('change', filterGames);
    });
})