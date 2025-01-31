# Traffic Light

## State Transition Diagram

| Current State                                 | Trigger | Next State                                    | Notes |
|-----------------------------------------------|---------|-----------------------------------------------|-------|
| North & South => Green && East & West => Red  | Yield   | North & South => Yellow && East & West => Red |       |
| North & South => Yellow && East & West => Red | Stop    | North & South => Red && East & West => Red    |       |
| North & South => Red && East & West => Red    | Go      | North & South => Red && East & West => Green  |       |
