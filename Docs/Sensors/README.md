```
PositioningSystem: {
    Receiver: {
        frequency: float,
        signals: [
            myPosition: vec2,
        ],
    },
}
```

```
Radar: {
	Transmitter: {
		maxPower: int,
		rechargeRate: float,
		wavePattern: [
            power: float,
        ],
	},
	Receiver: {
        filters: [],
        echoes: [
            entityId: int,
            distance: float,
            direction: float,
            (distance, direction, myPosition) = entityPosition: vec2,
        ],
	},
}
```
