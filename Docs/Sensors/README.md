```
PositioningSystem: {
    Receiver: {
        Frequency: float,
        Signals: [
            MyPosition: vec2,
        ],
    },
}
```

```
Radar: {
	Transmitter: {
		RechargeRate: float,
		WavePattern: [
            power: float,
        ],
	},
	Receiver: {
        Filters: [],
        Echoes: [
            EntityId: int,
            Distance: float,
            Heading: float,
            (Distance, Heading, MyPosition) = EntityPosition: vec2,
        ],
	},
}
```
