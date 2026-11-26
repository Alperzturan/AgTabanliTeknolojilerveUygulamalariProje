document.addEventListener("DOMContentLoaded", () => {
    const searchInput = document.querySelector("input[type=search]");
    const checkboxes = document.querySelectorAll(".filter");
    const gameCards = document.querySelectorAll(".game-cards");
    const countText = document.getElementById("gameCountText");
    const clearBtn = document.getElementById("clearFiltersBtn");
    const emptyMessage = document.getElementById("noGamesMessage");
    const resetButtons = document.querySelectorAll(".js-reset-filters");

    if (gameCards.length === 0) return;

    const totalGames = gameCards.length;

    const filterGames = () => {
        const searchText = searchInput ? searchInput.value.trim().toLowerCase() : "";

        const activeFilters = {};
        let hasActiveCheckbox = false;
        checkboxes.forEach(cb => {
            if (cb.checked) {
                hasActiveCheckbox = true;
                if (!activeFilters[cb.name]) activeFilters[cb.name] = [];
                activeFilters[cb.name].push(cb.value.toLowerCase());
            }
        });

        const hasAnyFilter = searchText.length > 0 || hasActiveCheckbox;
        let visibleCount = 0;

        gameCards.forEach(card => {
            const cardTitle = (card.dataset.title || "").toLowerCase();
            const matchesSearch = cardTitle.includes(searchText);

            let matchesFilters = true;
            for (const filterName in activeFilters) {
                const cardValue = (card.dataset[filterName] || "").toLowerCase();

                if (!activeFilters[filterName].includes(cardValue)) {
                    matchesFilters = false;
                    break;
                }
            }

            if (matchesFilters && matchesSearch) {
                card.classList.remove("d-none");
                visibleCount++;
            } else {
                card.classList.add("d-none");
            }
        });

        if (countText) {
            countText.innerHTML = `<i class="bi bi-grid-fill"></i> ${visibleCount} oyun listeleniyor`;
        }

        if (clearBtn) {
            clearBtn.classList.toggle("d-none", !hasAnyFilter);
        }

        if (emptyMessage) {
            emptyMessage.classList.toggle("d-none", visibleCount > 0);
        }
    };

    const resetAllFilters = () => {
        if (searchInput) searchInput.value = "";
        checkboxes.forEach(cb => { cb.checked = false; });
        filterGames();
    };

    if (searchInput) {
        searchInput.addEventListener("input", filterGames);
    }

    checkboxes.forEach(cb => {
        cb.addEventListener("change", filterGames);
    });

    if (clearBtn) {
        clearBtn.addEventListener("click", resetAllFilters);
    }

    resetButtons.forEach(btn => {
        btn.addEventListener("click", resetAllFilters);
    });
});