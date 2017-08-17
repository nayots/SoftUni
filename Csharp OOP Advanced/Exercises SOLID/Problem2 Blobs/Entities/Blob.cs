namespace _02.Blobs.Entities
{
    using _02.Blobs.Entities.Attacks;
    using _02.Blobs.Entities.Behaviors;

    public class Blob
    {
        private Attack attack;
        private int health;
        private int initialDamage;
        private int initialHealth;
        private int triggerCount;

        public Blob(string name, int health, int damage, Behavior behavior, Attack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.attack = attack;

            this.initialHealth = health;
            this.initialDamage = damage;
        }

        public Behavior Behavior { get; private set; }
        public int Damage { get; set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health <= this.initialHealth / 2 && !this.Behavior.IsTriggered)
                {
                    this.TriggerBehavior();
                }
            }
        }

        public string Name { get; private set; }

        public void Attack(Blob target)
        {
            this.attack.Execute(this, target);
        }

        public void Respond(int damage)
        {
            this.Health -= damage;
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"IBlob {this.Name} KILLED";
            }

            return $"IBlob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }

        public void TriggerBehavior()
        {
            if (!this.Behavior.IsTriggered)
            {
                this.Behavior.IsTriggered = true;
                this.Behavior.Trigger(this);
            }
        }

        public void Update()
        {
            if (this.Behavior.IsTriggered)
            {
                this.ApplyEffect();
            }
        }

        private void ApplyEffect()
        {
            this.Behavior.ApplyTriggerEffect(this);
        }

        private void ApplyRecurrentEffect()
        {
            this.Behavior.ApplyRecurrentEffect(this);
        }
    }
}